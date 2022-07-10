using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gknzby.Tools
{
    public class CarrierArea
    {
        //It's a carrier class and carriers carry cargo. Because of that, name of object that being carried is Cargo*****
        private readonly Transform _cargoTransform;
        private Vector3 _sourcePoint;

        private Vector3 _forwardDiff;
        private bool _forwardClamp;
        private Vector3 _frontedValue = Vector3.zero;

        private Vector3 _rightDiff;
        private Vector3 _sidedValue = Vector3.zero;
        private bool _rightClamp;

        public CarrierArea(Transform cargoTransform, in Vector3 sourcePoint, in Vector3 forwardPoint, in Vector3 rightPoint, bool forwardClamp = true, bool rightClamp = true)
        {
            _cargoTransform = cargoTransform;
            _sourcePoint = sourcePoint;

            _forwardClamp = forwardClamp;
            _forwardDiff = forwardPoint - cargoTransform.position;

            _rightClamp = rightClamp;
            _rightDiff = rightPoint - sourcePoint;
        }

        private static float Clamp01(in float value)
        {
            float clampedValue = value < 0.0f ? 0.0f : value;
            return 1.0f < clampedValue ? 1.0f : clampedValue;
        }

        public void ForwardLerp(ref float lerp)
        {
            lerp = _forwardClamp ? CarrierArea.Clamp01(in lerp) : lerp;
            _frontedValue = _forwardDiff * lerp;
            _cargoTransform.position = _sourcePoint + _sidedValue + _frontedValue;
        }

        public void SideLerp(ref float lerp)
        {
            lerp = _rightClamp ? CarrierArea.Clamp01(in lerp) : lerp;
            _sidedValue = _rightDiff * lerp;
            _cargoTransform.position = _sourcePoint + _sidedValue + _frontedValue;
        }
    }
}
