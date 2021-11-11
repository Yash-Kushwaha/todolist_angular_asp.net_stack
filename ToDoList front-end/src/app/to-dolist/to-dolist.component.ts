import { Component, OnInit } from '@angular/core';
import TodoItem from '../Models/TodoList';
import { v4 as uuidv4 } from "uuid";
import { ServicesService } from '../services.service';

@Component({
  selector: 'app-to-dolist',
  templateUrl: './to-dolist.component.html',
  styleUrls: ['./to-dolist.component.css']
})
export class ToDolistComponent implements OnInit {

  constructor(private service:ServicesService) { }
  public todoitem: string;
  public TodoList: Array<TodoItem> = []
  ngOnInit(): void {
    this.service.GetItems().subscribe((data:any)=>{
      this.TodoList=data;
    });
  }
  AddItem() {
    this.TodoList.push({ id: uuidv4(), text: this.todoitem, isCompleted: false });
    console.log(this.TodoList);
    var obj = { id: uuidv4(), text: this.todoitem, isCompleted: false };
    this.service.PostItem(obj).subscribe(data=>console.log(data));
  }

  RemoveItem(id:any){
    this.TodoList = this.TodoList.filter(x=>x.id!=id);
    this.service.DeleteItem(id).subscribe(data=>console.log(data));
  }
  UpdateItem(id: any) {
    let item = this.TodoList.find(x => x.id == id);
    item.isCompleted = item.isCompleted ? false : true;
    this.service.UpdateItem(id, item).subscribe((data: any) => console.log(data));
  }

}
