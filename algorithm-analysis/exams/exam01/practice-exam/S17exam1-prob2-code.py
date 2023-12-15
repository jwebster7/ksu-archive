

def Modulo(x, y):
	q = 0
	r = x
	while y <= r:
		q += 1
		r = r - y 
	return q, r
	
	
user_input = []

for i in range(1,3):
	number = int(input('Please enter a number: '))
	user_input.append(number)
	
print('User input: ' + str(user_input))

print('Modulo: ' + str(Modulo(user_input[0], user_input[1])))