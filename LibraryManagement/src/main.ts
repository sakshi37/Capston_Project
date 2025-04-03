import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
// import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
bootstrapApplication(AppComponent, appConfig).catch((err) =>
  console.error(err)
);
