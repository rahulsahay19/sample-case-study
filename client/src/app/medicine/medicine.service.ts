import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';
import { MedicineParams } from '../shared/models/medicineParams';
import { IMedicine } from '../shared/models/medicine';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {
  baseUrl = 'https://localhost:5001/api/v1/';
  medicineParams = new MedicineParams();
  constructor(private http: HttpClient) { }

  getMedicines(medicineParams: MedicineParams) {
    let params = new HttpParams();
    params = params.append('pageIndex', medicineParams.pageNumber.toString());
    params = params.append('pageSize', medicineParams.pageSize.toString());

    if (medicineParams.search) {
      params = params.append('search', medicineParams.search);
      return this.http.get<IPagination>(this.baseUrl + 'Medicine/bySearchTerm', { observe: 'response', params })
        .pipe(
          map(response => {
            // IPagination object
            return response.body;
          })
        );
    }
    return this.http.get<IPagination>(this.baseUrl + 'Medicine/byBrandName/' + medicineParams.brand, { observe: 'response', params })
      .pipe(
        map(response => {
          // IPagination object
          return response.body;
        })
      );
  }

  editMedicine(medicine: IMedicine) {
    return this.http.put<IMedicine>(this.baseUrl + 'Medicine/modifyMedicine', medicine);
  }

  getMedicine(id: number) {
    return this.http.get<IMedicine>(this.baseUrl + 'Medicine/byId/' + id);
  }

  saveMedicine(medicine: IMedicine) {
    return this.http.post<IMedicine>(this.baseUrl + 'Medicine/createMedicine', medicine);
  }

  deleteMedicine(id: number) {
    return this.http.delete(this.baseUrl + 'Medicine/deleteById/' + id);
  }

  setMedicineParams(params: MedicineParams) {
    this.medicineParams = params;
  }

  getMedicineParams() {
    return this.medicineParams;
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'Medicine/getBrands');
  }
}
