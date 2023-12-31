﻿/* UserInterface.cs
 * Author: Rod Howell 
 * Edit: Joe Webster
 * Date: 11/13/2017
  */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Ksu.Cis300.Graphs;
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.ShortestPaths
{
    /// <summary>
    /// A GUI for a program to find shortest paths on a map.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The current map data.
        /// </summary>
        private DirectedGraph<string, decimal> _map = new DirectedGraph<string, decimal>();

        /// <summary>
        /// The delimiter for splitting query strings.
        /// </summary>
        private char[] _ampersand = { '&' };

        /// <summary>
        /// The internet access protocol for the map server.
        /// </summary>
        private const string _mapServerScheme = "http";

        /// <summary>
        /// The host name of the map server.
        /// </summary>
        private const string _mapServerHost = "www.openstreetmap.org";

        /// <summary>
        /// The absolute path for the main map.
        /// </summary>
        private const string _mainMapPath = "/";

        /// <summary>
        /// The separator character for query strings.
        /// </summary>
        private const string _querySeparator = "&";

        /// <summary>
        /// The query string for the bounding box.
        /// </summary>
        private string _bounds;

        /// <summary>
        /// An encoded comma for query strings.
        /// </summary>
        private const string _commaCode = "%2C";

        /// <summary>
        /// The 'bbox' query string.
        /// </summary>
        private const string _bbox = "bbox=";

        /// <summary>
        /// The prefix of a URL path displaying a single node.
        /// </summary>
        private const string _nodePrefix = "/node/";

        /// <summary>
        /// The text to show the units for the distance.
        /// </summary>
        private const string _distanceUnit = " miles";

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the shortest paths
        /// </summary>
        /// <param name="u">generic string</param>
        /// <param name="v">generic string</param>
        /// <param name="map">DirectedGraph map</param>
        /// <param name="paths">Dictionary paths</param>
        /// <returns></returns>
        private decimal ShortestPath(string u, string v, DirectedGraph<string, decimal> map, out Dictionary<string, string> paths)
        {
            paths = new Dictionary<string, string>();
            MinPriorityQueue<decimal, Edge<string, decimal>> tempQueue = new MinPriorityQueue<decimal, Edge<string, decimal>>();
            paths.Add(u, u);
            if (u.Equals(v))
            {
                return 0;
            }
            foreach (Edge<string, decimal> outGoEdge in map.OutgoingEdges(u))
            {
                tempQueue.Add(outGoEdge.Data, outGoEdge);
            }
            while (tempQueue.Count > 0) //possibly wrong
            {
                decimal p = tempQueue.MinimumPriority;
                Edge<string, decimal> edgeRemoved = tempQueue.RemoveMinimumPriority();
                if (!paths.ContainsKey(edgeRemoved.Destination))
                {
                    paths.Add(edgeRemoved.Destination, edgeRemoved.Source);
                    if (edgeRemoved.Destination.Equals(v))
                    {
                        return p;
                    }
                    foreach (Edge<string, decimal> outGoEdge in map.OutgoingEdges(edgeRemoved.Destination))
                    {
                        tempQueue.Add(p + outGoEdge.Data, outGoEdge);
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Adds a path
        /// </summary>
        /// <param name="u">generic string</param>
        /// <param name="v">generic string</param>
        /// <param name="paths">Dictionary passed in</param>
        /// <param name="list">List passed in</param>
        private void AddPath(string u, string v, Dictionary<string, string> paths, IList list)
        {
            Stack<string> tempStack = new Stack<string>();
            
            while (!u.Equals(v))
            {
                tempStack.Push(v);
                v = paths[v];
            }
            list.Add(u);
            while (tempStack.Count > 0)
            {
                list.Add(tempStack.Pop());
            }
        }

        /// <summary>
        /// Handles a "Load a map" event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoad_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _map = ReadMap(uxOpenDialog.FileName);
                    ShowEntireMap();
                    uxEntireMap.Enabled = true;
                    uxFindPath.Enabled = false;
                    uxStartNode.Text = "";
                    uxEndNode.Text = "";
                    uxDistance.Text = "";
                    uxNodeList.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Shows the entire map.
        /// </summary>
        private void ShowEntireMap()
        {
            UriBuilder url = new UriBuilder(_mapServerScheme, _mapServerHost);
            url.Query = _bounds;
            uxMap.Navigate(url.Uri);
        }

        /// <summary>
        /// Reads the map data from the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file to read.</param>
        /// <returns>A graph containing the map data.</returns>
        private DirectedGraph<string, decimal> ReadMap(string fileName)
        {
            DirectedGraph<string, decimal> map = new DirectedGraph<string, decimal>();
            using (StreamReader input = File.OpenText(fileName))
            {
                string line = input.ReadLine();
                SetMapBounds(line.Split(','));
                while (!input.EndOfStream)
                {
                    line = input.ReadLine();
                    string[] fields = line.Split(',');
                    map.AddEdge(fields[0], fields[1], Convert.ToDecimal(fields[2]));
                }
            }
            return map;
        }

        /// <summary>
        /// Sets the map bounds to the given box.
        /// </summary>
        /// <param name="box">The coordinates of the lower left corner and upper right corner
        /// of the map.</param>
        private void SetMapBounds(string[] box)
        {
            _bounds = _bbox + box[0] + _commaCode + box[1] + _commaCode + box[2] + _commaCode + box[3];
        }

        /// <summary>
        /// Handles an "Entire map" event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEntireMap_Click(object sender, EventArgs e)
        {
            ShowEntireMap();
        }

        /// <summary>
        /// Handles a Set Start event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSetStart_Click(object sender, EventArgs e)
        {
            uxStartNode.Text = GetNodeFromMap();
            EnablePathFinding();
        }

        /// <summary>
        /// Handles a Set End event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSetEnd_Click(object sender, EventArgs e)
        {
            uxEndNode.Text = GetNodeFromMap();
            EnablePathFinding();
        }

        /// <summary>
        /// Gets the node currently being browsed.
        /// </summary>
        /// <returns>The node currently being browsed.</returns>
        private string GetNodeFromMap()
        {
            uxDistance.Text = "";
            uxNodeList.Items.Clear();
            return uxMap.Url.AbsolutePath.Substring(_nodePrefix.Length);
        }

        /// <summary>
        /// Displays an error message indicating that the given node is not on the map.
        /// </summary>
        /// <param name="node">The node.</param>
        private void ShowError(string node)
        {
            MessageBox.Show("Node " + node + " not in map.");
        }

        /// <summary>
        /// Handles a Selected Index Changed event on the node list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UriBuilder url = new UriBuilder(_mapServerScheme, _mapServerHost);
            url.Path = _nodePrefix + uxNodeList.SelectedItem;
            uxMap.Navigate(url.Uri);
        }

        /// <summary>
        /// Fixes URIs in which part of the query comes after the fragment.
        /// </summary>
        /// <param name="url">The URI to fix.</param>
        /// <returns>The fixed URI.</returns>
        private UriBuilder FixFragment(Uri url)
        {
            UriBuilder fixedUrl = new UriBuilder(url);
            string frag = url.Fragment;
            int amp = frag.IndexOf(_querySeparator);
            if (amp >= 0)
            {
                string queryExtra = frag.Substring(amp);
                fixedUrl.Fragment = fixedUrl.Fragment.Substring(0, amp).Substring(1);
                if (fixedUrl.Query.Length > 1)
                {
                    fixedUrl.Query = fixedUrl.Query.Substring(1) + queryExtra;
                }
                else
                {
                    fixedUrl.Query = queryExtra.Substring(1);
                }
            }
            return fixedUrl;
        }

        /// <summary>
        /// Handles a "Text Changed" event on the "Starting Node" TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStartNode_TextChanged(object sender, EventArgs e)
        {
            EnablePathFinding();
        }

        /// <summary>
        /// Enables the "Find Shortest Path" button if values are present for both nodes.
        /// </summary>
        private void EnablePathFinding()
        {
            uxFindPath.Enabled = uxStartNode.Text != "" && uxEndNode.Text != "";
        }

        /// <summary>
        /// Handles a "Text Changed" event on the "Ending Node" TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEndNode_TextChanged(object sender, EventArgs e)
        {
            EnablePathFinding();
        }

        /// <summary>
        /// Handles a Navigated event on the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMap_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (uxMap.Url.Host == _mapServerHost)
            {
                bool viewingNode = uxMap.Url.AbsolutePath.StartsWith(_nodePrefix) &&
                    _map.ContainsNode(uxMap.Url.AbsolutePath.Substring(_nodePrefix.Length));
                uxSetStart.Enabled = viewingNode;
                uxSetEnd.Enabled = viewingNode;
            }
            else
            {
                uxSetStart.Enabled = false;
                uxSetEnd.Enabled = false;
                uxFindPath.Enabled = false;
            }
        }

        private void uxFindPath_Click(object sender, EventArgs e)
        {
            if (!_map.ContainsNode(uxStartNode.Text))
            {
                ShowError(uxStartNode.Text);
            }
            else if (!_map.ContainsNode(uxEndNode.Text))
            {
                ShowError(uxEndNode.Text);
            }
            else
            {
                Dictionary<string, string> paths;
                decimal len = Math.Round(ShortestPath(uxStartNode.Text, uxEndNode.Text, _map, out paths), 1);
                uxNodeList.Items.Clear();
                if (len < 0)
                {
                    uxDistance.Text = "";
                    MessageBox.Show("No path found.");
                }
                else
                {
                    uxDistance.Text = len + _distanceUnit;
                    uxNodeList.BeginUpdate();
                    AddPath(uxStartNode.Text, uxEndNode.Text, paths, uxNodeList.Items);
                    uxNodeList.EndUpdate();
                }
            }
        }
    }
}
