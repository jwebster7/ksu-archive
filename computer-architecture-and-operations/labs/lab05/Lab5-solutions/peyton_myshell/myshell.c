//
// myShell.c - Shell Template
//
// Developer: Sample Solution
//
#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <string.h>
#include <unistd.h>
#include <string.h>
#include <ctype.h>
#include <signal.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <errno.h>
#include "myShell.h"

#define MAXLINE 100
int timeout;
double currentCycles;
double MHZ;
int shotCount = 0;
int myPid;
int pid[20];

//
// Signal handler
//
void sighandler(int signo)
{
  switch(signo)
  {
    case SIGINT:
      printf("\n\n*** Caught SIGINT signal ***\n\n");
      currentCycles = get_counter(); // get current counter value
      printf("Elapsed Time: %f seconds.\n", currentCycles/MHZ/1.0E6);
      start_counter(); // reset the counter
      printf("mysh>");
      fflush(stdout);
      break;
    case SIGALRM:
      printf("\n\n*** Alarm caught ***\n\n");
      printf("mysh>");
      fflush(stdout);
      break;
    case SIGUSR1:
	  shotCount++;
	  printf("I've been shot %d ***\n", myPid);
      if (shotCount>=4)
      {
		printf("Process %d is dead...\n", myPid);
		exit(0);
      }
      break;
    default:
      printf("\n\n*** Caught unexpected signal number %d ***\n\n", signo);
      printf("mysh>");
      fflush(stdout);
      break;
  }
  return;
}

//
// Wildcat shootout game
//
void shootout(int n)
{
  int i, j, ret;
  char *argv[21] = { (char *) 0 };
  signal(SIGTERM, SIG_IGN);
  signal(SIGINT, SIG_IGN);
  signal(SIGUSR1, SIG_IGN);

  argv[0] = (char *) malloc(10);
  sprintf(argv[0],"./wildcat");
  for (i=0; i<n; i++)
  {
    argv[i+1] = (char *) malloc(10);
    if ((pid[i]=fork())==0)
	{
	  argv[i+1] = (char *) 0;
      myPid = getpid();
      printf("Created child %d with pid %d\n", i+1, myPid);
      // call execve to execute the code and pass in command line args
      execve("./wildcat" , argv, NULL);
      perror("Unable to execute ./wildcat, exiting");
      exit(1);
    }
    else
    {
      sprintf(argv[i+1],"%d", pid[i]);
      // in the parent update the list of command line args to include
      // the pid of the child just created
    }
  }
  // parent waits for n-1 children to exit
  for (i=1; i<n; i++)
  {
    ret = wait(NULL); // wait on any child to exit, return value = pid
    if (ret>0)
    {
      for (j=0; j<n; j++)
      {
		if (pid[j]==ret)
			pid[j]=-1; // mark the child as terminated
      }
    }
  }
  // parent identifies the last remaining child 
  for (j=0; j<n; j++)
  {
	if (pid[j]>0)
	{
	  printf("Congratulations, process %d (pid = %d), you win!\n",j,pid[j]);
	  printf("Unfortunately, I have to kill you now.\n");
	  kill(pid[j],9); // kill the winner
	  pid[j]=-1;
	}
  }
  // parent exits
  exit(0);
}

//
// Display options
//
void options()
{
  printf("\n  OPTIONS:\n");
  printf("------------------------------------------\n");
  printf("  A <sec> = Alarm <sec> seconds\n");
  printf("  P = Process Status Tree (ps --forest)\n");
  printf("  W = Who is logged in and how many are logged in (who -q)\n");
  printf("  F <key> = Fortune cookie (fortune -m <key>)\n");
  printf("  G <num> = Game - execute wildcat shootout game with <num> wildcats\n");
  printf("  L [dir] = Directory listing (ls -al [ dir ])\n");
  printf("  N [filename] = Number lines in file or stdin (cat -n [filename])\n");
  printf("  S = Start or restart timer \n");
  printf("  E = Elapsed time \n");
  printf("  I <signo> = Ignore signal number <signo>\n");
  printf("  C <signo> = Catch signal number <signo>\n");
  printf("  D <signo> = Default action for signal <signo>\n");
  printf("  K <signo> <pid> = Send signal <signo> to process with pid <pid>\n");
  printf("  H = Help\n");
  printf("  Q = Quit\n");
  printf("------------------------------------------\n");
  fflush(stdout);
  return;
}

//
// Main fetch and evaluate routine
//
int main()
{
  int retval;
  int status;
  char cmd[MAXLINE+1] = " ";
  char *cptr[10];
  int seconds;
  int pid, signum;
  int i, n, count;
  int fd;

  // invoke signal hander, sighandler, when some signals are received
  signal(SIGINT, sighandler);
  signal(SIGUSR1, sighandler);
  signal(SIGALRM, sighandler);
  // determine system clock rate
  MHZ = mhz(0);

  while(strncmp(cmd,"Q",1)!=0)
  {
    printf("\nmysh>");
    fflush(stdout);
    memset(cmd,0,MAXLINE+1);
    if ((fgets(cmd, MAXLINE, stdin) == NULL) && ferror(stdin))
    {
      perror("fgets error");
      exit(1);
    }
    cmd[0] = toUpper(cmd[0]); // Convert first character to upper-case
    // Extract tokens from command entered
    count = split(cmd, cptr, 10);

    if (feof(stdin)) // Ctrl-D -- end-of-input
    {
      exit(0);
    }

    if(count > 0)
    {
	  switch((char)(*cptr[0]))
      {
        case 'P': case 'W': case 'F': case 'G': case 'L': case 'N':
        retval = fork(); // fork off a child to do the work.
        if (retval==0)
        {
          // add code to redirect output to a file if one of the
          // arguments is '>', the following argument is the filename
          i = -1;
          int size = sizeof(cptr)-1;
          for (int j = 0; j < size && cptr[j+1] != NULL; j++){
             if (cptr[j][0] == '>') {
                i = j;
                break;
             }
          }
          fd = -1;
          if(i > 0)
          {
             fd = open(cptr[i+1], O_WRONLY|O_CREAT|O_APPEND,S_IRUSR|S_IWUSR);
             if(fd < 0)
             {
                 perror("can't open file");
                 continue;
             }
             else dup2(fd, 1);
             cptr[i] = "\0";
             count = i;
          }


		  switch((char)(*cptr[0]))
          {
            case 'P':
                     if (cptr[1]!=NULL)
                          execl("/bin/ps","ps", "--forest", "-u", (char *)cptr[1],(char *) NULL);
                     else
                          execl("/bin/ps","ps","--forest", (char *) NULL);
                      exit(1); // just in case it didn't work :-)
                      break;
            case 'W': execl("/usr/bin/who","who","-q", (char *) NULL);
                      exit(2);
                      break;
			case 'F': if(cptr[1] != NULL) execl("/usr/games/fortune", "fortune", "-m", (char *) cptr[1], (char *) NULL);
		      else execl("/usr/games/fortune", "fortune", (char *) NULL);
                      break;
                      exit(3);
            case 'L': if (cptr[1]!=NULL)
						execl("/bin/ls","ls", "-al",(char *)cptr[1],(char *) NULL);
					  else
						execl("/bin/ls","ls","-al",".", (char *) NULL);
                      exit(4);
                      break;
            case 'N': 
                      exit(5);
                      break;
			case 'G': if (cptr[1]!=NULL)
					  {
						n = atoi(cptr[1]);
						if (n>20)
							n=20;
						if (n<2)
							n=2;
						shootout(n);
					  }
					  break;
            default:  printf("Invalid user input, try again.\n");
                      exit(5);
                      break;
          }
          return 0; // child should always exit...
        }
        else
        {
          retval = wait(&status); // parent shell waits for child to exit
        }
        break;

        case 'A': seconds = atoi(cptr[1]);
                alarm(seconds);
                break;
        case 'S': // reset the counter
                start_counter();
                break;
        case 'E': currentCycles = get_counter();
				printf("Elapsed Time: %f seconds.\n", currentCycles/MHZ/1.0E6);
                break;
        case 'I': // ignore the signal
                signum = atoi(cptr[1]);
                signal(signum, SIG_IGN);
                break;
        case 'C': // catch the signal
                signum = atoi(cptr[1]);
                signal(signum, sighandler);
                break;
        case 'D': signum = atoi(cptr[1]);
                signal(signum,SIG_DFL);
                break;
        case 'K': // send a signal
                if ((char *) cptr[1] != NULL && (char *) cptr[2] != NULL) kill(atoi(cptr[1]), atoi(cptr[2]));
                break;
        case 'H': options();
                break;
        case 'Q': // do nothing
                break;
        default:  printf("Invalid user input, try again.\n");
                break;
      }
    }
  }
  return 0;
}
