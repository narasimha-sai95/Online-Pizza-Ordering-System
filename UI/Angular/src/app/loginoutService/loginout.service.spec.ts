import { TestBed } from '@angular/core/testing';

import { LoginoutService } from './loginout.service';

describe('LoginoutService', () => {
  let service: LoginoutService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginoutService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
