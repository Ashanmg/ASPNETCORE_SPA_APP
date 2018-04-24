import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models: any;
  features: any;
  vehicles:any= {
    features:[],
    contact: {}
  };

  constructor(
    private vehicleService: VehicleService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.vehicleService.getMake().subscribe(makes =>
      this.makes = makes);
    
    this.vehicleService.getFeature().subscribe(features =>
      this.features = features);
  }

  onMakeChange() {
    let selectedMake = this.makes.find (m=> m.id == this.vehicles.makeId);
    console.log(selectedMake);
    this.models = selectedMake? selectedMake.models : [];
    delete this.vehicles.modelId;
  }
  
  onFeaturesChange(featureId, $event){
    if ($event.target.checked)
      this.vehicles.features.push(featureId);
    else {
      var index = this.vehicles.features.indexOf(featureId);
      this.vehicles.features.splice(index,1);
    }
  }

  submit(){
    console.log("submit clicked");
    this.vehicleService.createVehicle(this.vehicles)
    .subscribe( 
      x => console.log(x),
      err => {
        this.toastrService.error("An unexpected error happened.");
      }
    );
  }

}
