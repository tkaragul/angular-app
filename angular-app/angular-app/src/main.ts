/// <reference types="@angular/localize" />

import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';



//import { HttpClientModule } from '@angular/common/http';

bootstrapApplication(AppComponent, {providers: [ ...appConfig.providers]})
  .catch((err) => console.error(err));
