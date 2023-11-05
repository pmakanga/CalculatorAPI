import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { CalculatorComponent } from './calculator.component';
import { CalculatorService } from '../calculator.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CalculatorComponent],
      providers: [CalculatorService],
      imports: [HttpClientTestingModule, FormsModule, ],
    });
    fixture = TestBed.createComponent(CalculatorComponent);
    component = fixture.componentInstance;
  });

  it('should calculate correctly for addition', fakeAsync(() => {
    component.firstNumber = 5;
    component.secondNumber = 3;
    component.selectedOperator = 'add';

    component.calculate();

    tick(); // Simulate passage of time until all pending asynchronous activities finish

    expect(component.result).toEqual(8);
  }));

  it('should calculate correctly for subtraction', fakeAsync(() => {
    component.firstNumber = 10;
    component.secondNumber = 5;
    component.selectedOperator = 'subtract';
  
    component.calculate();
  
    tick();
  
    expect(component.result).toEqual(5);
  }));

  it('should calculate correctly for multiplication', fakeAsync(() => {
    component.firstNumber = 4;
    component.secondNumber = 3;
    component.selectedOperator = 'multiply';
  
    component.calculate();
  
    tick();
  
    expect(component.result).toEqual(12);
  }));

  it('should handle division by zero gracefully', fakeAsync(() => {
    component.firstNumber = 8;
    component.secondNumber = 0;
    component.selectedOperator = 'divide';
  
    component.calculate();
  
    tick();
  
    // Use a type assertion to handle the string result from division by zero.
    expect(component.result as number | string).toEqual('Cannot divide by zero');
  }));
  
  it('should reset the result when clearing the calculator', fakeAsync(() => {
    component.firstNumber = 6;
    component.secondNumber = 2;
    component.selectedOperator = 'add';
  
    component.calculate();
  
    tick();
  
    expect(component.result).toEqual(8);
  
    // Use a type assertion for the clear method.
    (component as any).clear(); // Assuming clear exists, or adjust as needed
  
    expect(component.result).toBeNull();
  }));
  
});
