import json

def store_user_data():
    # Ask for user input
    name = input("Enter your name: ")
    location = input("Enter your location: ")
    age = input("Enter your age: ")

    # Create a dictionary to store the data
    user_data = {
        "name": name,
        "location": location,
        "age": age
    }

    # Write the data to a JSON file
    with open('user_data.json', 'w') as json_file:
        json.dump(user_data, json_file)

    print("User data has been saved to 'user_data.json'.")

# Call the function
store_user_data()