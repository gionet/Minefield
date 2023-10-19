# Minefield DFS method - WITH ALLY

def main():
    
    # Edit your n*m grid
    # 'O' = path
    # '#' = minefield
    field = [
        ['#', 'O', '#', '#', '#'],
        ['#', 'O', 'O', '#', 'O'],
        ['O', '#', '#', 'O', 'O'],
        ['O', '#', '#', 'O', '#'],
        ['#', '#', 'O', '#', 'O'],
        ['#', 'O', '#', '#', '#'],
    ]

    # Define starting point
    start_row = 0
    start_col = None

    # Search for starting point (entrance)
    for col in range(len(field[0])):
        if field[start_row][col] == 'O':
            start_col = col
            break
    
    # If no entrance
    if start_col is None:
        print("No starting point found in row 0")
        
    else:
        safe_path = find_safe_path(field, start_row, start_col)

        if safe_path:
            path = safe_path[0]
            ally = safe_path[1]

            print("CROSSING MINEFIELD COMPLETED")
            print(f"Totoshka's Path: {path}")
            print(f"Ally's Path: {ally}")
            
        else:
            print("No safe path found")
            
    
def find_safe_path(field, start_row, start_col):
    # 8 moving directions (Horizontal, Vertical, Diogonal)
    # Movement Priority: down-left > down > down-right > left > right > up-left > up > up-right 
    directions = [(1, -1), (1, 0), (1, 1), (0, -1), (0, 1), (-1, -1), (-1, 0), (-1, 1)]
    rows = len(field)
    cols = len(field[0])
    visited = {}
    path_ally = []
    path = []
        
    def dfs(row, col, ally_row, ally_col):
        if rows < 0 or row >= rows or col < 0 or col >= cols or (row, col) in visited or field[row][col] == '#':
            return False
        
        # Save visited platform into stack
        visited[(row, col)] = True
        path.append((row, col))

        # Ally always behind Toto by 1
        if len(path) > 1:
            path_ally.append((ally_row, ally_col))
        
        # # To print path (FOR DEBUG)
        # print(f'Toto path: {path}')
        # print(f'Ally path: {path_ally}')
        
        # Goal : if reached last row
        if row == rows - 1:
            return path
        
        # Attempt all 8 directions
        for direction in directions:
            new_row = row + direction[0]
            new_col = col + direction[1]
            new_ally_row = row
            new_ally_col = col
            
            # Return True if next potential step is clear
            if dfs(new_row, new_col, new_ally_row, new_ally_col):
                return True
        
        # If Toto path exhausted, pop Ally first then Toto
        if path_ally and len(path_ally) > 0:
            path_ally.pop()
        path.pop()
    
        # # To print path after pop() (FOR DEBUG)
        # print(f'Toto path: {path}')
        # print(f'Ally path: {path_ally}')
        
        # To check for collisions (Toto and Ally != same spot)
        if len(path) > 0 and len(path_ally) > 0:
            if path[-1] == path_ally[-1]:
                raise Exception("Totoshka and Ally collided!")
            
    # Return Toto and Ally path if true    
    try:
        if dfs(start_row, start_col, -1, -1):
            return path, path_ally
        else:
            return None
        
    except Exception as e:
        print(e)
        return None

main()