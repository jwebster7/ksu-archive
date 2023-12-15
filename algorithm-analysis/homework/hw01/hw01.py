import random

# size = 12
element_list = [1, 2, 2, 2, 3, 5, 6, 8, 9, 10, 15, 17]

# initialize x
x = 0

# x = value, A = array to search, n = size of the array
def BinarySearch(x, A, n):
	# P
	low = 1
	high = n - 1
	q = (low + high) // 2
	
	while A[q] != x:
		if A[q] < x:
			# T
			low = q + 1
		else:
			# E
			high = q - 1
		q = (low + high) // 2
		
	return q

def RecursiveBinarySearch(low, high, q):

	if element_list[q] != x:
		if element_list[q] < x:
			# T
			low = q + 1
			q = (low + high) // 2
			return RecursiveBinarySearch(low, high, q)
		else:
			# E
			high = q - 1
			q = (low + high) // 2
			return RecursiveBinarySearch(low, high, q)
		
	return q
		
		
def Find(low, high):
	q = (low + high) // 2
	if element_list[q] != x:
		if element_list[q] < x:
			low = q + 1
		else:
			high = q - 1
		return Find(low, high)
	return q
	
x = int(input('Please enter a value to search for: '))

print('\nOriginal array: ' + str(element_list))

search_result = BinarySearch(x, element_list, 12)
print('\nIndex of "x" using iteration: ' + str(search_result))

# P
# q = len(element_list) // 2

recursive_result = Find(0, 11)
print('\nIndex of "x" using recursion: ' + str(recursive_result))







