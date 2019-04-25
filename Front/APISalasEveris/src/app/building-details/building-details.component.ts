import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Building } from '../Entities/Building';
import { BuildingService } from '../Services/building.service';
import { Office } from '../Entities/Office';
import { OfficeService} from '../Services/office.service';


@Component({
  selector: 'app-building-details',
  templateUrl: './building-details.component.html',
  styleUrls: ['./building-details.component.css']
})
export class BuildingDetailsComponent implements OnInit {
    buildingsList:Building[];
    officesList:Office[];
    officeSelected:string="0";
  constructor(private route: ActivatedRoute, private location:Location, private buildingService:BuildingService,
    private officeService:OfficeService) { }

  ngOnInit() {
    this.getBuilding();
    this.getOffices();
  }

  getBuilding(){
    const buildingId=+this.route.snapshot.paramMap.get('id');
    this.buildingService.getBuilding(buildingId).subscribe(Building=>this.buildingsList=Building);
  }

  getOffices(){
    this.officeService.getOffices().subscribe(Offices=>this.officesList=Offices);
  }
  save(){
    this.buildingService.updateBuilding(this.buildingsList[0]).subscribe(()=>this.goBack());
  }
  goBack(): void {
    this.location.back();
  }
  create(officeId: number,buildingName:string,street:string,numberOfStreet:number){
    numberOfStreet=isNaN(numberOfStreet)?0:numberOfStreet; 
    buildingName=buildingName.trim();
    street=street.trim();
    if(!numberOfStreet) {return;}
    if(!buildingName) {return;}
    if(!street) {return;}
    if(!officeId) {return;}
    this.buildingService.createBuilding({officeId,street,buildingName,numberOfStreet} as Building).subscribe(()=>this.goBack());

  }
}
