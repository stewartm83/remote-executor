import json

a = {'name':'Sarah', 'age': 24, 'isEmployed': True }

def retjson():
    python2json = json.dumps(a)
    print python2json
    
retjson()
