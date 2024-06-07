import java.lang.reflect.Field;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;

@Aspect
public class MyInitAspect {

    @Before("execution(*.new(..)) && target(target)")
    public void initializeFields(Object target) throws IllegalAccessException {
        Class<?> clazz = target.getClass();

        for (Field field : clazz.getDeclaredFields()) {
            if (field.isAnnotationPresent(MyInit.class)) {
                field.setAccessible(true);
                if (field.get(target) == null) {
                    if (field.getType().equals(Object.class)) {
                        field.set(target, new Object());
                    } else if (field.getType().equals(String.class)) {
                        field.set(target, new String());
                    }
                    // Add more cases for other types if needed
                }
            }
        }
    }
}