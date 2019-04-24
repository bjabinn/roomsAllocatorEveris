import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule  } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Room } from '../Entities/room';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})

export class RoomService {
  
  
  url="https://localhost:5004/api/Room";
  constructor(private http: HttpClient) { }

  
 /**Get the RoomsList */
  getRooms(): Observable<any>{
    return this.http.get(this.url).pipe(catchError(this.handleError<any>('getRooms',[])));
  }
  /**Get the room by id */
  getRoom(roomId: number): Observable<any>{
    return this.http.get(this.url + "/" + roomId).pipe(catchError(this.handleError<any>('getRoom id=${id}')));
  }

  /**Put: update a room on the server */
  updateRoom(room:Room): Observable<any>{
    return this.http.put(this.url+ "/" + room.roomId,room,httpOptions)
    .pipe(catchError(this.handleError<any>('updateRoom')));
  }

  /** Post: create a room on the server */
  create(room: Room): Observable<any> {
    return this.http.post(this.url,room,httpOptions).pipe(catchError(this.handleError<any>("createRoom")));
  }
  /**Delete: delete a room from the server */
  delete(roomId: number):Observable<any>{
    return this.http.delete(this.url + "/" + roomId,httpOptions).pipe(catchError(this.handleError<any>('deleteRoom')));
  }
  searchRooms(search:string):Observable<any>{
    if(!search.trim()){
      return of([]);
    }
    return this.http.get(`${this.url}/name/${search}`).pipe(catchError(this.handleError<any>('searchRooms',[])));
  }

  //Errors
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
   
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
   
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
   
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
private log(message: string) {
 
}

}
