import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes:any[];
  models:any[];
  features:any[];
  vehicles:any= {};

  constructor(
    private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMake().subscribe(makes =>
      this.makes = makes);
    
    this.vehicleService.getFeature().subscribe(features =>
      this.features = features);
  }

  onMakeChange() {
    let selectedMake = this.makes.find(m => m.id == this.vehicles.make);
    console.log(selectedMake);
    this.models = selectedMake? selectedMake.models : [];
  } 

}
