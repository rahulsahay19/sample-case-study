import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IMedicine } from '../shared/models/medicine';
import { MedicineParams } from '../shared/models/medicineParams';
import { MedicineService } from './medicine.service';

@Component({
  selector: 'app-medicine',
  templateUrl: './medicine.component.html',
  styleUrls: ['./medicine.component.scss']
})
export class MedicineComponent implements OnInit {
  medicines: IMedicine[];
  brands: IBrand[];
  medicineParams = new MedicineParams();
  totalCount: number;
  @ViewChild('search', { static: true }) searchTerm: ElementRef;
  constructor(private medicineService: MedicineService) { }

  ngOnInit(): void {
    this.getMedicines();
    this.getBrands();
  }

  getMedicines() {
    this.medicineService.getMedicines(this.medicineParams).subscribe(response => {
      this.medicines = response.data;
      this.medicineParams.pageNumber = response.pageIndex;
      this.medicineParams.pageSize = response.pageSize;
      this.totalCount = response.count;
      console.log(response);
    }, error => {
      console.log(`An error ocurred while fetching medicines:- ${error}`);
    });
  }

  getBrands() {
    this.medicineService.getBrands().subscribe(response => {
      //this.brands = response;
      this.brands = [{ brand: 'All' }, ...response];
    }, error => {
      console.log(`An error ocurred while fetching brands:- ${error}`);
    });
  }

  onBrandSelected(brand: string) {
    this.medicineParams.brand = brand;
    this.medicineParams.pageNumber = 1;
    this.getMedicines();
  }

  onPageChanged(event: any) {
    this.medicineParams.pageNumber = event;
    this.getMedicines();
  }

  onSearch() {
    this.medicineParams.search = this.searchTerm.nativeElement.value;
    this.medicineParams.pageNumber = 1;
    this.getMedicines();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.medicineParams = new MedicineParams();
    this.getMedicines();
  }
}
