#create a function which cubes an even number
# and throws exception for odd number
def cube_even_number(num):
    if num % 2 != 0:
        raise ValueError("The number is odd. Please provide an even number.")
    return num ** 3 
