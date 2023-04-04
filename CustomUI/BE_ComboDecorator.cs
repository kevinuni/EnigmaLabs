using System;
using System.Collections.Generic;
using System.Reflection;

namespace ControlsUI
{
    public class BE_ComboDecorator<T>// : IEnumerable<T>
    {
        private T m_beEntity;

        public T BE_Entity
        {
            get
            {
                return m_beEntity;
            }
        }

        public BE_ComboDecorator(T entity)
        {
            this.m_beEntity = entity;
        }

        #region ICombo Members

        public string DisplayMember
        {
            get
            {
                string _displayMember = "";
                Type aType = m_beEntity.GetType();
                _displayMember = aType.InvokeMember("DisplayMember", BindingFlags.GetProperty, null, m_beEntity, null).ToString();
                return _displayMember;
            }
        }

        public string AlternativeDisplayMember
        {
            get
            {
                string _alternativeDisplayMember = "";
                Type aType = m_beEntity.GetType();
                _alternativeDisplayMember = aType.InvokeMember("AlternativeDisplayMember", BindingFlags.GetProperty, null, m_beEntity, null).ToString();
                return _alternativeDisplayMember;
            }
        }

        public string ValueMember
        {
            get
            {
                string _valueMember = "";
                Type aType = m_beEntity.GetType();
                _valueMember = aType.InvokeMember("ValueMember", BindingFlags.GetProperty, null, m_beEntity, null).ToString();
                return _valueMember;
            }
        }

        #endregion ICombo Members

        public static List<BE_ComboDecorator<T>> ListFactory(List<T> listOfEntities)
        {
            List<BE_ComboDecorator<T>> listOfDecorators = new List<BE_ComboDecorator<T>>();
            foreach (T beEntity in listOfEntities)
            {
                listOfDecorators.Add(new BE_ComboDecorator<T>(beEntity));
            }
            return listOfDecorators;
        }
    }
}