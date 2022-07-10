using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Tools
{
    public class CarrierLine
    {
        //It's a carrier class and carriers carry cargo. Because of that, name of object that being carried is Cargo*****
        private readonly Transform _cargoTransform;
        private readonly bool _clamped = true;
        private readonly Vector3 _sourceVector;
        private readonly Vector3 _diffVector;
        private float _deltaLerp = 0;

        public CarrierLine(Transform cargoTransform, in Vector3 sourceVector, in Vector3 destinationVector, in bool clamped = true)
        {
            //source + (destination - source)*lerp
            //source + diff * lerp
            //To do not calculate every step (destination - source) value
            _cargoTransform = cargoTransform;
            _sourceVector = sourceVector;
            _clamped = clamped;
            _diffVector = destinationVector - sourceVector;
        }

        public CarrierLine(CarrierLine carrierLine, Transform cargoTransform)
        {
            _cargoTransform = cargoTransform;
            _clamped = carrierLine._clamped;
            _sourceVector = carrierLine._sourceVector;
            _diffVector = carrierLine._diffVector;
        }

        private static float Clamp01(in float value)
        {
            float clampedValue = value < 0.0f ? 0.0f : value;
            return 1.0f < clampedValue ? 1.0f : clampedValue;
        }

        public void Lerp(float lerp)
        {
            lerp = _clamped ? CarrierLine.Clamp01(in lerp) : lerp;
            _cargoTransform.position = _sourceVector + _diffVector * lerp;
        }

        public void DeltaLerp(float deltaLerp, out bool isReached)
        {
            _deltaLerp += deltaLerp;
            _cargoTransform.position += _diffVector * deltaLerp;
            isReached = 1f < _deltaLerp;
        }


        public Vector3 GetLerpedPosition(float lerp)
        {
            lerp = _clamped ? CarrierLine.Clamp01(in lerp) : lerp;
            return _sourceVector + _diffVector * lerp;
        }
    }
}
