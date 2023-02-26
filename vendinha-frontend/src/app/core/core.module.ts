import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { throwIfAlreadyLoaded } from './guards/module-import.guard';
import { InterceptorModule } from './interceptors/interceptor.module';
@NgModule({
  imports: [HttpClientModule, InterceptorModule],
  exports: [],
  declarations: [],
  providers: [
    
  ],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
