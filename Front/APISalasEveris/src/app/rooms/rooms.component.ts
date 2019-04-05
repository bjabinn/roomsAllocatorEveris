import { Component, OnInit } from '@angular/core';
import { Room } from '../room';
import { RoomService } from "../room.service"

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent implements OnInit {
  roomsList: Room[];
  title="Everis Center Rooms";
    constructor( private roomService: RoomService) { }
  ngOnInit() {
    this.getRooms();
  }
  getRooms(): void{
    this.roomService.getRooms().subscribe(RoomsList=>this.roomsList=RoomsList);
  }
  delete(room:Room):void{
    this.roomsList=this.roomsList.filter(r=>r!==room);
    this.roomService.delete(room.roomId).subscribe();
  }

}
