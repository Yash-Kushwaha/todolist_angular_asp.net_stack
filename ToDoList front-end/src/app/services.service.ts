import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import TodoItem from './Models/TodoList';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private http:HttpClient) { }
  PostItem(item:TodoItem){
    return this.http.post('https://localhost:44385/api/ToDoItems',item);
  }

  GetItems(){
    return this.http.get('https://localhost:44385/api/ToDoItems');
  }

  DeleteItem(id:any){
    return this.http.delete(`https://localhost:44385/api/ToDoItems/${id}`);
  }

  UpdateItem(id:any, item:TodoItem){
    return this.http.put(`https://localhost:44385/api/ToDoItems/${id}`,item);
  }
}
