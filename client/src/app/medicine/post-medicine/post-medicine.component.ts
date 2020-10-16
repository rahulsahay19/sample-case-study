import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { IMedicine } from 'src/app/shared/models/medicine';
import { MedicineService } from '../medicine.service';

@Component({
  selector: 'app-post-medicine',
  templateUrl: './post-medicine.component.html',
  styleUrls: ['./post-medicine.component.scss']
})
export class PostMedicineComponent implements OnInit {
  medicine: IMedicine = {
    id: 0,
    name: '',
    brand: '',
    expiryDate: new Date().toISOString(),
    price: 0,
    quantity: 0,
    text: ''
  }
  constructor(private medicineService: MedicineService, private router: Router) { }

  ngOnInit(): void {
  }

  submit() {
    const medicineToCreate = this.createMedicine();
    var date = new Date(this.medicine.expiryDate);
    console.log(date);
    var today = new Date();
    console.log(new Date(today.getFullYear(), today.getMonth(), today.getDate() + 30));
    if (date < (new Date(today.getFullYear(), today.getMonth(), today.getDate() + 30))) {
      console.log('Medicine less than 30 days cannot be posted');
    } else {
      this.medicineService.saveMedicine(medicineToCreate).subscribe(med => {
        console.log('Medicine successfully created!');
        this.router.navigate(['/medicine'])
      }, error => {
        console.log(error);
      });
    }
  }

  private createMedicine(): IMedicine {
    return <IMedicine>{
      name: this.medicine.name,
      brand: this.medicine.brand,
      price: this.medicine.price,
      expiryDate: this.medicine.expiryDate,
      quantity: this.medicine.quantity,
      text: this.medicine.text
    };
  }
}
