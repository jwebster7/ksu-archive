'''
Author: Joseph Webster & Michael Yangmi
Date: 03.13.19
Class: CIS 575 | Introduction to Algorithm Analysis
Professor: Dr. Torben Amtoft
'''
# Problem 7

# global variable to hold the total amount of swaps.
swaps = 0

# This class was inspired by the following code: http://interactivepython.org/courselib/static/pythonds/Trees/BinaryHeapImplementation.html
class Heap:
	def __init__(self):
		self.heap_list = [0]
		self.current_size = 0

	def PercolateUp(self,i):
		global swaps
		while i // 2 > 0:
			if self.heap_list[i] < self.heap_list[i // 2]:
				tmp = self.heap_list[i // 2]
				self.heap_list[i // 2] = self.heap_list[i]
				self.heap_list[i] = tmp
				swaps = swaps + 1
		i = i // 2

	def Insert(self,k):
		self.heap_list.append(k)
		self.current_size = self.current_size + 1
		self.PercolateUp(self.current_size)

	def PercolateDown(self,i):
		global swaps
		while (i * 2) <= self.current_size:
			minimum_child = self.FindMinimumChild(i)
			if self.heap_list[i] > self.heap_list[minimum_child]:
				temp = self.heap_list[i]
				self.heap_list[i] = self.heap_list[minimum_child]
				self.heap_list[minimum_child] = temp
				swaps = swaps + 1
			i = minimum_child

	def FindMinimumChild(self,i):
		if i * 2 + 1 > self.current_size:
			return i * 2
		else:
			if self.heap_list[i*2] < self.heap_list[i*2+1]:
				return i * 2
			else:
				return i * 2 + 1

	def DeleteMinimumChild(self):
		temp_val = self.heap_list[1]
		self.heap_list[1] = self.heap_list[self.current_size]
		self.current_size = self.current_size - 1
		self.heap_list.pop()
		self.PercolateDown(1)
		return temp_val

	def Heapify(self,alist):
		i = len(alist) // 2
		self.current_size = len(alist)
		self.heap_list = [0] + alist[:]
		while (i > 0):
			self.PercolateDown(i)
			i = i - 1
			
	def Sort(self):
		count = 0
		while count < len(self.heap_list):
			self.DeleteMinimumChild()
			count = count + 1
			
# Generate an array of 'pseudo-random' values with a size 'n'.
def PseudoRandom(n):
	# create a list of all 1's of size 'n'; the initial values do not matter as they will be overwritten.
	array = [1] * n
	
	# initialize a counter.
	i = 0

	# loop from 0, 1, 2, ..., n and fill the arrays with pseudo-random values.
	while (i < n):
		array[i] = (13 * i) % n
		i = i + 1
	return array

# Produces an almost ordered array of given length 'n'.
def AlmostOrdered(n):
	# initialize the array with no values 
	array = [None] * n

	# initialize a counter.
	i = 0

	# loop from 0, 1, 2, ..., n and fill the arrays with almost ordered values.
	while (i < n):
		if i % 13 == 12:
			array[i] = (i + 13) % n
		else:
			array[i] = i
		i = i + 1
	return array
	
heap = Heap()

# n = 100
print('N = 100\n')
swaps = 0
heap.Heapify(PseudoRandom(100))
heap.Sort()
print('Pseudo-Random Swaps: ' + str(swaps))
swaps = 0
heap.Heapify(AlmostOrdered(100))
heap.Sort()
print('Almost-Ordered Swaps: ' + str(swaps))\

# n = 1000
print('N = 1000\n')
swaps = 0
heap.Heapify(PseudoRandom(1000))
heap.Sort()
print('Pseudo-Random Swaps: ' + str(swaps))
swaps = 0
heap.Heapify(AlmostOrdered(1000))
heap.Sort()
print('Almost-Ordered Swaps: ' + str(swaps))

# n = 10000
print('N = 10000\n')
swaps = 0
heap.Heapify(PseudoRandom(10000))
heap.Sort()
print('Pseudo-Random Swaps: ' + str(swaps))
swaps = 0
heap.Heapify(AlmostOrdered(10000))
heap.Sort()
print('Almost-Ordered Swaps: ' + str(swaps))