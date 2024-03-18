import math

def seat_in_train(number):
    
    # все нижние места нечетные
    if number % 2 == 0:
        s_symbol = 'в'
    else: s_symbol = 'н'
    
    # боковые койки в диапазоне от 37 до 54
    if 37 <= number <= 54:
        b_symbol = 'б'
    else: b_symbol = 'к'
    
    # если боковушка, то идем от обратного, 
    # а если купе, то находим номер блока поделив номер на количество мест в купе и округлив в большую сторону
    if b_symbol == 'б':
        n_symbol = 9 - int((number - 37) / 2)
    else:
        n_symbol = math.ceil(number / 4)
    
    return str(n_symbol) + b_symbol + s_symbol

print(seat_in_train(int(input("Введите место в поезде = "))))