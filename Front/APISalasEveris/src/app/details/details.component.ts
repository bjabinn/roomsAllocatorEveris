import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../Entities/room';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { RoomService } from '../Services/room.service';
import { Building } from '../Entities/Building';
import { BuildingService } from '../Services/building.service';
import { Office } from '../Entities/Office';
import { OfficeService} from '../Services/office.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})




export class DetailsComponent implements OnInit {
  room: Room;
  roomListForm:Room[];
  buildings:Building[];
  offices:Office[];
  officeSelected:string="0";
  buildingSelected:string="0";
  constructor(private route: ActivatedRoute, private location: Location, private roomService: RoomService,
     private officeService: OfficeService, private buildingService: BuildingService) { }
 
  ngOnInit():void {
    this.getRoom();
    this.getOffices();
  }

  getRoom(){
    const roomId=+this.route.snapshot.paramMap.get('id');
    this.roomService.getRoom(roomId).subscribe(Room=>this.roomListForm=Room);
  }
  getOffices(){
    this.officeService.getOffices().subscribe(Offices=>this.offices=Offices);
  }
  save():void{
    this.roomService.updateRoom(this.roomListForm[0]).subscribe(()=>this.goBack());
  }
  create(buildingId: number,roomName:string,floor:number,numRoom:string){
    floor=isNaN(floor)?0:floor; 
    roomName=roomName.trim();
    numRoom=numRoom.trim();
    if(!roomName) {return;}
    if(!floor) {return;}
    if(!numRoom) {return;}
    if(!buildingId) {return;}
    this.roomService.create({buildingId,roomName,floor,numRoom} as Room).subscribe(()=>this.goBack());
  }
  goBack(): void {
    this.location.back();
  }
  getBuilding(buildingId:number){
    this.buildingService.getBuilding(buildingId).subscribe(Buildings=>this.buildings=Buildings);
    return this.buildings[0];
  }
  loadBuildingsByOfficeId(){
    console.log(+this.officeSelected);
    this.buildingService.getBuildingsByOfficeId(+this.officeSelected).subscribe(
      Buildings=>{this.buildings=Buildings;
        console.log('data',this.buildings);
    
    });
  }
}
