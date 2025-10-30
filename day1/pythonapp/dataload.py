import csv

# Define the file path for the CSV file
file_path = "emp.csv"

# Open the CSV file and read its contents
with open(file_path, mode='r') as file:
    csv_reader = csv.reader(file)
    
    # Read and display the header row
    header = next(csv_reader)
    print("Header:", header)
    
    # Read and display each row of data
    print("Data:")
    for row in csv_reader:
        print(row)