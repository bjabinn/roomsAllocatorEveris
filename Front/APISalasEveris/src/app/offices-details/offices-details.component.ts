import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from  '@angular/router';
import { Location } from '@angular/common';
import { OfficeService } from '../Services/office.service';
import { Office } from '../Entities/Office';

@Component({
  selector: 'app-offices-details',
  templateUrl: './offices-details.component.html',
  styleUrls: ['./offices-details.component.css']
})
export class OfficesDetailsComponent implements OnInit {

  office:Office;
  officesList:Office[];
  constructor(private location:Location,private route:ActivatedRoute,private officeService:OfficeService) { }

  ngOnInit() {
    this.getOffice();
  }

  getOffice(){
    const officeId=+this.route.snapshot.paramMap.get('id');
    console.log(officeId);
    this.officeService.getOffice(officeId).subscribe(Office=>this.office=Office);
  }
  save(){
    this.officeService.updateOffice(this.office).subscribe(()=>this.goBack());
  }
  create(officeName:string,alias:string){
    officeName=officeName.trim();
    alias=alias.trim();
    if(!officeName) {return;}
    if(!alias) {return;}
    this.officeService.createOffice({officeName,alias} as Office).subscribe(()=>this.goBack());


  }
  goBack(){
    this.location.back();
  }
}
