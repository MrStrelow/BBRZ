import java.lang.reflect.Field;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;

@Aspect
public class MyInitAspect {

    @Before("execution(*.new(..)) && target(target)")
    public void initializeFields(Object target) throws IllegalAccessException, InstantiationException {
        for (Field field : target.getClass().getDeclaredFields()) {
            if (field.isAnnotationPresent(MyInit.class)) {
                field.setAccessible(true);
                if (field.get(target) == null) {
                    field.set(target, field.getType().newInstance());
                }
            }
        }
    }
}