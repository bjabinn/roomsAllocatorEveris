import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule  } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Building } from  '../Entities/Building';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  url="https://localhost:5004/api/Buildings";
  constructor(private http: HttpClient) { }

  getBuildings(): Observable<any>{
    return this.http.get(this.url).pipe(catchError(this.handleError<any>("getBuildings",[])));
  }
  getBuildingsByOfficeId(officeId:number){
    return this.http.get(this.url + "/office/" + officeId).pipe(catchError(this.handleError<any>("getBuildingByOfficeId")));
  }
  getBuilding(id:number): Observable<any>{
    return this.http.get(this.url + "/" + id).pipe(catchError(this.handleError<any>("getBuild "+id,)))
  } 
  updateBuilding(building:Building): Observable<any>{
    return this.http.put(this.url + "/" + building.buildingId,building,httpOptions).pipe(catchError(this.handleError<any>("Update a building")));
  }
  createBuilding(building:Building): Observable<any>{
    return this.http.post(this.url,building,httpOptions).pipe(catchError(this.handleError<any>("create building: " + building.buildingName)))
  }
  deleteBuilding(buildingId:number): Observable<any>{
    return this.http.delete(this.url + "/" + buildingId,httpOptions).pipe(catchError(this.handleError<any>("deleteBuilding: "+buildingId,)))
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
