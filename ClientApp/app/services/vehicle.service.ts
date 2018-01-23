import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(private http: Http) { }

  getFeature() {
    return this.http.get('api/vehicle/features')
      .map(res => res.json());
  }
  getMake(){
    return this.http.get('api/vehicle/makes')
    .map(res => res.json());
  }
}
