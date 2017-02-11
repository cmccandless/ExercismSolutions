from itertools import permutations
def solution():
    nHouses=5 #Constraint 1
    perms=list(permutations(range(nHouses)))
    first,second,middle,fourth,last=list(range(5))
    for (eng,jap,nor,span,ukr) in perms:
        if nor is not first: continue #Constraint 10
        for (red,blue,green,ivory,yellow) in perms:
            if eng is not red: continue #Constraint 2
            if green is not ivory+1: continue #Constraint 6
            if blue is not second: continue #Constraint 15+10
            for (ches,kools,lucky,parl,old) in perms:
                if yellow is not kools: continue #Constraint 8
                if jap is not parl: continue #Constraint 14
                for (coffee,milk,oj,tea,water) in perms:
                    if coffee is not green: continue #Constraint 4
                    if tea is not ukr: continue #Constraint 5
                    if milk is not middle: continue #Constraint 9
                    if oj is not lucky: continue #Constraint 13
                    for (dog,horse,fox,snails,zebra) in perms:
                        if span is not dog: continue #Constraint 3
                        if snails is not old: continue #Constraint 7
                        if ches-fox not in {1,-1}: continue #Constraint 11
                        if kools-horse not in {1,-1}: continue #Constraint 12
                        t=[{eng:'Englishman',jap:'Japanese',nor:'Norwegian',
                            span:'Spaniard',ukr:'Ukrainian'}[x] for x in (water,zebra)]
                        return ('It is the {} who drinks the water.\n'
                            'The {} keeps the zebra.').format(*t)