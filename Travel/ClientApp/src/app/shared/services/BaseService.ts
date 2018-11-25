import { Observable } from 'rxjs/Rx';

export abstract class BaseService
{
  constructor() { }

  protected handleError(error: any)
  {
    var appError = error.headers.get('Application-Error');

    if (appError)
    {
      return Observable.throw(appError);
    }

    var modelStateErrors: string = "";
    var serverError = error.json();

    if (!serverError.type)
    {
      for (var key in serverError) {
        if (serverError[key])
        {
          modelStateErrors += serverError[key] + '\n';
        }
      }

      modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
      return Observable.throw(modelStateErrors || 'Server error');
    }
  }
}
