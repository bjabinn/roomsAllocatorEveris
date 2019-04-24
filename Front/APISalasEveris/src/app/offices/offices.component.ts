import { Component, OnInit } from '@angular/core';
import { Office } from '../Entities/Office';
import { OfficeService } from '../Services/office.service';

@Component({
  selector: 'app-offices',
  templateUrl: './offices.component.html',
  styleUrls: ['./offices.component.css']
})
export class OfficesComponent implements OnInit {

  officesList:Office[];
  constructor(private officeService:OfficeService) { }

  ngOnInit() {
    this.getOffices();
  }

  getOffices(){
    this.officeService.getOffices().subscribe(offices=>this.officesList=offices);
  }

  delete(office:Office):void{
    this.officesList=this.officesList.filter(r=>r!==office);
    this.officeService.deleteOffice(office.officeId).subscribe();
  }
}
