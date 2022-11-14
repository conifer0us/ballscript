using UnityEngine; 

namespace LanguageObjects {

    // Interface that handles object manipulation, data storage, and data accessibility for data elements in the scene 
    public interface DataFunctionality<T> {
        public void placeObject(Vector3 direction, T data);

        public T getDataValue();
    }
}