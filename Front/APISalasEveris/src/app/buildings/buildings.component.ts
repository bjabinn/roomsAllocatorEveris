import { Component, OnInit } from '@angular/core';
import { Building } from '../Entities/Building';
import { BuildingService } from '../Services/building.service';


@Component({
  selector: 'app-buildings',
  templateUrl: './buildings.component.html',
  styleUrls: ['./buildings.component.css']
})
export class BuildingsComponent implements OnInit {

  buildingsList: Building[];
  constructor(private buildingService: BuildingService) { }

  ngOnInit() {
    this.getBuildings();
  }

  getBuildings(){
    this.buildingService.getBuildings().subscribe(buildings=>this.buildingsList=buildings);
  }
  delete(building:Building):void{
    this.buildingsList=this.buildingsList.filter(b=>b!==building);
    this.buildingService.deleteBuilding(building.buildingId).subscribe();
  }
}
