import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class HttpUtilityService {

    constructor(private http: Http) {
        //TODO centralize this somewhere
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');

        this.options = new RequestOptions({ headers: this.headers });
    }

    private headers: Headers;
    private options: RequestOptions;

    public get(route: string) {
        return this.http.get(route, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public post(route: string, model: any) {
        var postData = (model == null) ? null : JSON.stringify(model);
        return this.http.post(route, postData, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public delete(route: string) {
        console.log(route);
        return this.http.delete(route, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public extractData(res: Response) {
        let body;
        
        if (res.text()) {
            body = res.json();
            return body || {};
        }

        return {};
    }

    public handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }

        //return Observable.throw(errMsg);
        return Observable.throw(errMsg || 'backend server error');
    }
}