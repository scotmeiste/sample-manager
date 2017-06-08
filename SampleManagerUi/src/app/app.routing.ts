import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SamplesComponent } from './components/samples/samples.component';
import { SamplesStatusComponent } from './components/samples-status/samples-status.component';
import { SamplesNameComponent } from './components/samples-name/samples-name.component';
import { SamplesAddComponent } from './components/samples-add/samples-add.component';

const routes: Routes = [
    { path: '', redirectTo:"/samples/all", pathMatch: "full" },
    { path: 'samples/all', component: SamplesComponent },
    { path: 'samples/status', component: SamplesStatusComponent },
    { path: 'samples/name', component: SamplesNameComponent },
    { path: 'samples/add', component: SamplesAddComponent }
]

@NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
})
export class AppRouting {}