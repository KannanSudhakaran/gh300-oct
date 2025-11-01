import unittest
from mathcalc import cube_even_number

class TestCubeEvenNumber(unittest.TestCase):
    
    def test_cube_positive_even_number(self):
        """Test cubing a positive even number"""
        self.assertEqual(cube_even_number(2), 8)
        self.assertEqual(cube_even_number(4), 64)
        self.assertEqual(cube_even_number(6), 216)
    
    def test_cube_zero(self):
        """Test cubing zero (even number)"""
        self.assertEqual(cube_even_number(0), 0)
    
    def test_cube_negative_even_number(self):
        """Test cubing a negative even number"""
        self.assertEqual(cube_even_number(-2), -8)
        self.assertEqual(cube_even_number(-4), -64)
    
    def test_odd_number_raises_exception(self):
        """Test that odd numbers raise ValueError"""
        with self.assertRaises(ValueError) as context:
            cube_even_number(1)
        self.assertEqual(str(context.exception), "The number is odd. Please provide an even number.")
        
        with self.assertRaises(ValueError):
            cube_even_number(3)
        
        with self.assertRaises(ValueError):
            cube_even_number(5)
    
    def test_negative_odd_number_raises_exception(self):
        """Test that negative odd numbers also raise ValueError"""
        with self.assertRaises(ValueError):
            cube_even_number(-1)
        
        with self.assertRaises(ValueError):
            cube_even_number(-3)
    
    def test_large_even_number(self):
        """Test cubing a large even number"""
        self.assertEqual(cube_even_number(100), 1000000)

if __name__ == '__main__':
    unittest.main()