import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';

@NgModule({
    imports: [MatFormFieldModule, MatInputModule, MatTableModule, MatSelectModule, MatButtonModule],
    exports: [MatFormFieldModule, MatInputModule, MatTableModule, MatSelectModule, MatButtonModule]

})
export class MaterialModule {}
