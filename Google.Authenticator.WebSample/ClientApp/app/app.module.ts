import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { HttpModule, JsonpModule } from '@angular/http';

import { MaterializeDirective } from 'angular2-materialize';

import { AppComponent } from './app.component'
import { Configuration } from './app.constants';
import { routing } from './app.routes';
import { HomeComponent } from './home/home.component';

import { HttpUtilityService } from './services/http-utility.service';
import { ErrorService } from './services/error.service';
import { QRCodeService } from './services/qrcode.service';
import { UUIDService } from './services/uuid.service';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        HomeComponent,
        MaterializeDirective
    ],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        routing,
        HttpModule,
        JsonpModule
    ],
    providers: [
        Configuration,
        HttpUtilityService,
        ErrorService,
        QRCodeService,
        UUIDService
    ]
})
export class AppModule {
}
