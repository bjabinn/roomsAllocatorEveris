import { Component, OnInit } from '@angular/core';
import { Room } from '../Entities/room';
import { RoomService } from "../Services/room.service";
import { Observable, Subject } from 'rxjs';
import {
  debounceTime, distinctUntilChanged, switchMap
} from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  roomsList$: Observable<Room>;
  private searchTerms = new Subject();
  constructor(private roomService:RoomService) { }

  search(term: string): void {
    this.searchTerms.next(term);
  }
  ngOnInit(){
    this.roomsList$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),
 
      // ignore new term if same as previous term
      distinctUntilChanged(),
 
      // switch to new search observable each time the term changes
      switchMap((term: string) => this.roomService.searchRooms(term)),
    );
  }
  
  

}
