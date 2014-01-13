using System;

namespace ProyectoCraft.Entidades.GlobalObject
{
    public abstract class IdentifiableObject: IComparable, IIdentifiableObject
    {
        private Int64 _id;

        public virtual Int64 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public virtual Int32 Id32
        {
            get { return (Int32)this._id; }
            set { this._id = value; }
        }

        public virtual void Initialize()
        {

        }

        public virtual bool IsNew
        {
            get { return this.Id == 0; }
        }

        public virtual string GetUniqueCode()
        {
            return Id.ToString();
        }


        #region IComparable Members

        public virtual int CompareTo(object obj)
        {
            IdentifiableObject reference = obj as IdentifiableObject;
            if (reference == null)
            {
                return 1;
            }
            return this.Id.CompareTo(reference.Id);
        }

        public override bool Equals(object obj)
        {
            IdentifiableObject reference = obj as IdentifiableObject;
            if (reference == null)
            {
                return false;
            }

            if (this.Id.Equals(0) && reference.Id.Equals(0))
            {
                return object.ReferenceEquals(this, reference);
            }
            return this.CompareTo(obj).Equals(0);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}
