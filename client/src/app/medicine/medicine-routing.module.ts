import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MedicineComponent } from './medicine.component';
import { MedicineDetailsComponent } from './medicine-details/medicine-details.component';
import { EditMedicineComponent } from './edit-medicine/edit-medicine.component';
import { PostMedicineComponent } from './post-medicine/post-medicine.component';

const routes: Routes = [
  { path: '', component: MedicineComponent },
  { path: 'post', component: PostMedicineComponent },
  { path: ':id', component: MedicineDetailsComponent },
  { path: 'edit/:id', component: EditMedicineComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class MedicineRoutingModule { }
