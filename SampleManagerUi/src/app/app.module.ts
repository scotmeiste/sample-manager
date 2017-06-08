import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MdTabsModule } from '@angular/material';
import { MdButtonModule } from '@angular/material';
import { MdSelectModule } from '@angular/material';
import { MdInputModule } from '@angular/material';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppRouting } from './app.routing';

import { AppComponent } from './app.component';

import { SamplesService } from './services/samples.service';
import { SamplesComponent } from './components/samples/samples.component';
import { SamplesStatusComponent } from './components/samples-status/samples-status.component';
import { SamplesListComponent } from './components/samples-list/samples-list.component';
import { SamplesNameComponent } from './components/samples-name/samples-name.component';
import { UserService } from './services/user.service';

import 'rxjs/add/operator/toPromise';
import { SamplesAddComponent } from './components/samples-add/samples-add.component';

@NgModule({
  declarations: [
    AppComponent,
    SamplesComponent,
    SamplesStatusComponent,
    SamplesListComponent,
    SamplesNameComponent,
    SamplesAddComponent
  ],
  imports: [
    AppRouting,
    BrowserModule,
    BrowserAnimationsModule,
    MdTabsModule,
    MdButtonModule,
    MdSelectModule,
    MdInputModule,
    HttpModule,
    FormsModule
  ],
  providers: [
    SamplesService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
