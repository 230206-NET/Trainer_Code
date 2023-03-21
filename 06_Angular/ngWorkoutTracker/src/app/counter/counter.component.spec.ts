import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CounterComponent } from './counter.component';

describe('CounterComponent', () => {
  let component: CounterComponent;
  let fixture: ComponentFixture<CounterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CounterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CounterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have default values', () => {
    expect(component.count).toBe(0);
    expect(component.arr.length).toBe(5);
    expect(component.show).toBeTrue();
  })

  it('should increment by one', () => {
    component.increment();

    expect(component.count).toBe(1);
  })

  it('should toggle show property', () => {
    component.toggleShow();

    expect(component.show).toBeFalse();
  })

  it('should click on increment btn to increment', () => {
    const htmlElem = fixture.nativeElement as HTMLElement;

    const btn = htmlElem.querySelector('#increment-btn') as HTMLButtonElement;

    btn.click();

    expect(component.count).toBe(1);
  })

  it('should not display show div when show prop is false', () => {
    const htmlElem = fixture.nativeElement as HTMLElement;
    expect(htmlElem.querySelector('#show')).toBeTruthy();

    component.show = false;
    
    fixture.detectChanges();

    expect(htmlElem.querySelector('#show')).toBeFalsy();
  })
});
