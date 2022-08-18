# True means Island
# Falso means water

class Coordenada:
    def __init__(self, col, fil):
        self.col = col
        self.fila = fil


def es_inicio(fil, col, start_position):
    if( fil == start_position.fila and col == start_position.col):
        return True
    else:
        return False

def esta_dentro(nueva_fila, nueva_col,total_filas, total_columnas):
    if((nueva_fila<total_filas and nueva_fila >= 0) and (nueva_col<total_columnas and nueva_col >= 0)):
        return True
    else:
        return False    

def crear_matrix_vacia_pasos(cols_mapa, filas_mapa):
    matriz_pasos = [ [0 for cols in range(0,cols_mapa)] for filas in range(0,filas_mapa)]
    return matriz_pasos

def HasBFS_SobreIsla(start_position, mapa, pasos, total_filas, total_columnas):

    #crear el arreglo de direcciones
    #               N E S W
    direccionesXCOL =  [0, 1, 0, -1]
    direccionesYFILA = [-1, 0, 1, 0]

    mi_cola = []
    mi_cola.append(start_position)
    pasos[start_position.fila][start_position.col]=1

    tamano_isla = 0

    while(len(mi_cola)>0):
        #atender a quien le toca
        pos_tmp = mi_cola.pop()
        tamano_isla = tamano_isla + 1

        for dir_en_turno in range(0,4):
            nueva_fila = pos_tmp.fila + direccionesYFILA[dir_en_turno]
            nueva_col = pos_tmp.col + direccionesXCOL[dir_en_turno]

            #si no estoy dentro del mapa, no puedo
            #si hay agua, no puedo
            #si la matriz de pasos no es 0, tampoco puedo
            #tampoco puede ser el inicio del recorrido
            if((esta_dentro(nueva_fila, nueva_col,total_filas, total_columnas)) and\
                mapa[nueva_fila][nueva_col]!=False and \
                pasos[nueva_fila][nueva_col]==0 and \
                es_inicio(nueva_fila,nueva_col,start_position)==False
                ):

                pos_nueva = Coordenada(nueva_col,nueva_fila)
                mi_cola.append(pos_nueva)

                #marcar
                pasos[nueva_fila][nueva_col] = pasos[pos_tmp.fila][pos_tmp.col] + 1
    
    #cuando todos los elementos de la cola, fueron procesados

    return tamano_isla

def pasear_por_mapa(mapa, cols_mapa, filas_mapa):

    pasos = crear_matrix_vacia_pasos(cols_mapa,filas_mapa)

    lista_tamanos = []

    for fila in range(0, filas_mapa):
        for col in range(0, cols_mapa):
            #Si es isla && No he pasado por ahi, entonces
            if(mapa[fila][col]==True and pasos[fila][col]==0):
                #Hacer BFS

                tamano_isla_actual = HasBFS_SobreIsla(Coordenada(col,fila),mapa,pasos,filas_mapa,cols_mapa)
                lista_tamanos.append(tamano_isla_actual)
    
    print(lista_tamanos)


def print_mapa(mapa, total_fils,total_cols):

    for fil in range(0,total_fils):
        for col in range(0,total_cols):
            print('1'if mapa[fil][col] else '0',end=' ')
        print('\n')

def main():

    #mapa de 9 filas y 12 cols
    mapa = [
        [False,False,False,False,False,False,False,False,False,False,False,False],
        [False,True,False,False,True,False,True,False,False,False,False,False],
        [False,False,False,False,True,False,True,False,False,False,False,False],
        [False,False,False,False,True,False,True,False,False,False,False,False],
        [False,False,False,False,True,True,True,False,False,False,False,False],
        [False,True,False,False,False,False,False,False,False,False,False,False],
        [True,True,True,False,False,False,False,False,False,True,True,True],
        [False,True,False,False,False,False,False,False,False,False,False,False],
        [False,False,False,False,False,False,False,False,False,False,False,False]
    ]

    print_mapa(mapa,9,12)
    pasear_por_mapa(mapa,12,9)


main()

