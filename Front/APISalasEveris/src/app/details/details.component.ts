import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../room';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { RoomService } from '../room.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})


export class DetailsComponent implements OnInit {
  room: Room;
  constructor(private route: ActivatedRoute, private location: Location, private roomService: RoomService) { }

  ngOnInit():void {
    this.getRoom();
  }

  getRoom(): void{
    const roomId=+this.route.snapshot.paramMap.get('id');
    this.roomService.getRoom(roomId).subscribe(Room=>this.room=Room);
  }
  save():void{
    this.roomService.updateRoom(this.room).subscribe(()=>this.goBack());
  }
  create(name:string,floor:number,numRoom:string){
    floor=isNaN(floor)?0:floor; 
    name=name.trim();
    numRoom=numRoom.trim();
    if(!name) {return;}
    this.roomService.create({name,floor,numRoom} as Room).subscribe(()=>this.goBack());


  }
  goBack(): void {
    this.location.back();
  }
}
