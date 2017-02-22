declare module mcgtemplate_web.models {
    export interface httpResponse {
        result: any;
        id: number;
        exception?: any;
        status: number;
        isCanceled: boolean;
        isCompleted: boolean;
        creationOptions: number;
        asyncState?: any;
        isFaulted: boolean;
    }
}