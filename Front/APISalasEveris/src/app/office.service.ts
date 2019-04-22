import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule  } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Office } from './Entities/Office';

const httpOptions={
  headers: new HttpHeaders({'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  url="https://apisalaseveris.azurewebsites.net/api/offices";
  constructor(private http: HttpClient) { }
  
  getOffices(): Observable<any>{
    return this.http.get(this.url).pipe(catchError(this.handleError<any>("getOffices")));
  }
  getOffice(officeId:number):Observable<any>{
    return this.http.get(this.url+"/"+officeId).pipe(catchError(this.handleError<any>("getOffice")));
  }
  updateOffice(office:Office):Observable<any>{
    return this.http.put(this.http + "/"+office.officeId,office,httpOptions).pipe(catchError(this.handleError<any>("editOffices")));
  }
  createOffice(office:Office):Observable<any>{
    return this.http.post(this.url,office,httpOptions).pipe(catchError(this.handleError<any>("createOffice")));
  }
  deleteOffice(officeId:number):Observable<any>{
    return this.http.delete(this.url + "/" +officeId,httpOptions).pipe(catchError(this.handleError<any>("getOffices")));
  }


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
