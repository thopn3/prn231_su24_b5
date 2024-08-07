function getTodoItems(){
    let result = fetch("http://localhost:5000/api/todoitem")
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(err => console.error(err));
    return result;
}

getTodoItems();