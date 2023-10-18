# Minefield DFS method

def main():
    field = [
        ['#', 'O', '#', '#', '#'],
        ['#', 'O', 'O', '#', 'O'],
        ['O', '#', '#', 'O', 'O'],
        ['O', '#', 'O', 'O', '#'],
        ['#', '#', 'O', '#', '#'],
    ]

    start_row = 0
    start_col = None

    for col in range(len(field[0])):
        if field[start_row][col] == 'O':
            start_col = col
            break

    if start_col is None:
        print("No starting point found in row 0")
        
    else:
        safe_path = find_safe_path(field, start_row, start_col)
        if safe_path:
            for row, col in safe_path:
                print(f"({row}, {col})")
        else:
            print("No safe path found")
            
    
def find_safe_path(field, start_row, start_col):
    directions = [(1, -1), (1, 0), (1, 1), (0, -1), (0, 1), (-1, -1), (-1, 0), (-1, 1)]
    rows = len(field)
    cols = len(field[0])
    visited = {}
    path = []
    
    def dfs(row, col):
        if rows < 0 or row >= rows or col < 0 or col >= cols or (row, col) in visited or field[row][col] == '#':
            return False
        
        visited[(row, col)] = True
        path.append((row, col))

        if row == rows - 1:
            return True
        
        for direction in directions:
            new_row = row + direction[0]
            new_col = col + direction[1]
            if dfs(new_row, new_col):
                return True
            
        path.pop()
        return False
        
    if dfs(start_row, start_col):
        return path
    else:
        return None
    
main()