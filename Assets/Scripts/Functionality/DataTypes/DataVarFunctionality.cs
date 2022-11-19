using UnityEngine; 

namespace LanguageObjects {

    // Interface that handles object manipulation, data storage, and data accessibility for data elements in the scene 
    public interface DataVarFunctionality<T> {
        public void placeObject(T data);

        public T getDataValue();
    }
}