import json
import re

with open('Web Developer Test.json') as f:
    data = json.load(f)

'''I enhanced the regex, note this results in Olivar and Abigail
marked with an erroneous phone number, when they match per requirements.
I think a further discussion surrounding format would be needed.
A solution for this could be stripping out dashes and spaces from the
string and then validating regex for \d{10}. However, this would introduce
issues when someone provides the country code (up to 3 char). This would 
make it accept up to 13 digits. If strictly a us entity without regards
for potential int'l customers with int'l phon number, then only 11 would 
likely suffice. It just depends on the purpose of the data. I do realize this
will pick up the '+' character, but it's quite frequently formatted as such.

The same can be said for email to ensure the top level domain, e.g. 'com' (max length of 24
from a cursory search) is listed after the domain and a decimal.
'''
emailRegex = '^[a-z0-9]+[\._]?[a-z0-9]+[@]\w+[.]\w{2,24}$'
phoneRegex = '^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$'

citiesDict = {}

def add_dict_values (cityDict, key, valueIncrement):
    if key not in cityDict:
        cityDict[key] = valueIncrement
    else:
        cityDict[key] = cityDict.get(key) + valueIncrement
    return cityDict

for record in data:
    if(re.search(emailRegex,record["emailAddress"]) and re.search(phoneRegex,record["phoneNumber"])):
        print(record["fullName"] + " Valid")
        citiesDict = add_dict_values(citiesDict,record["cityName"],0)
    elif(re.search(emailRegex,record["emailAddress"])):
        print(record["fullName"] + " Phone is invalid.")
        citiesDict = add_dict_values(citiesDict,record["cityName"],1)
    elif(re.search(phoneRegex,record["phoneNumber"])):
        print(record["fullName"] + " Email is invalid.")
        citiesDict = add_dict_values(citiesDict,record["cityName"],1)
    else:
        print(record["fullName"] + " Email and Phone are invalid.")
        citiesDict = add_dict_values(citiesDict,record["cityName"],1)

print(dict(sorted(citiesDict.items(), key=lambda item: item[1], reverse=True)))